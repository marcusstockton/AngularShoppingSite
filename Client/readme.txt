Using Angular material for FE design
Angular material icons: https://material.io/tools/icons/?style=baseline



TODO:
Need to re-do item structure...
The ItemViewer should pass along the item to the item-form component
The ItemCreate needs thinking about...it doesn't work
The ItemEdit doesn't work

Look at https://www.npmjs.com/package/ng-chartjs for charts - for home page


How to copy auth code to variable in postman:

var data = JSON.parse(responseBody);
//console.log(data.tokens.accessToken);
postman.setEnvironmentVariable("AUTH_TOKEN", data.tokens.accessToken);

tests["Successful POST request"] = responseCode.code === 200;