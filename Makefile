#config default
buildType=Release

#ifinit Date Img and Src
infinitdate-src = infinitdate/
infinitdate-img = infinitdate

#test-webapp-inmemory Img and Src
test-webapp-inmemory-src = test-webapp-inmemory/
test-webapp-inmemory-img = test-webapp-inmemory

#test-webapi-bd Img and Src
test-webapi-bd-src = test-webapi-bd/
test-webapi-bd-img = test-webapi-bd

#Sql config
sql-name =sql1

all: publish build run

clearcontainer:
	docker rm -f ${test-webapi-bd-img}
	docker rm -f ${test-webapp-inmemory-img}
	docker rm -f ${infinitdate-img}

publish:
	dotnet publish ${test-webapi-bd-src} -c ${buildType}
	dotnet publish ${test-webapp-inmemory-src} -c ${buildType}
	dotnet publish ${infinitdate-src} -c ${buildType}

build:
	docker build -t ${test-webapi-bd-img} ${test-webapi-bd-src}
	docker build -t ${test-webapp-inmemory-img} ${test-webapp-inmemory-src}  
	docker build -t ${infinitdate-img} ${infinitdate-src}

run:
	docker run -d -p 80 --name ${test-webapi-bd-img} --link ${sql-name} ${test-webapi-bd-img}
	docker run -d -p 80 --name ${test-webapp-inmemory-img} ${test-webapp-inmemory-img}
	docker run --name ${infinitdate-img} --link ${test-webapi-bd-img} ${infinitdate-img} 