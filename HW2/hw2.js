// JavaScript source codefunction myFunction() {


function testfunction() {
    var cash = parseFloat(document.getElementById("datacost").value, 10); //convert input to int
    var tax = parseFloat(document.getElementById("datasale").value, 10); //convert input to int
    var payment = parseFloat(document.getElementById("datapayment").value, 10);
	var totalprice = (cash * tax) + cash;
    var totalstring = "";


	document.getElementById("demo").innerHTML = totalprice
	while (totalprice > 0){
        totalprice = totalprice - payment;
        totalstring = totalstring +  ("<li>" + totalprice + "</li>"); 
		
		
	}
	// totalstring = totalstring + "</p>"
     document.getElementById("demo").innerHTML = totalstring;
	
	
}
