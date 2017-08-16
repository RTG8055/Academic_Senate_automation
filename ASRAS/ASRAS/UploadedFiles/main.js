var http = require("http");

http.createServer(function (request, response){
	response.writehead(200,{'content-type':'text/plain'});
	response.end('Hello, World\n');
}).listen(8081);

console.log('server running at http://127.0.0.1:8081/');