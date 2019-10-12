// JavaScript source codefunction myFunction() {


function testfunction() {
    var cash = parseFloat(document.getElementById("datacost").value, 10); //convert input to float
    var tax = parseFloat(document.getElementById("datasale").value, 10); //convert input to float
    var payment = parseFloat(document.getElementById("datapayment").value, 10);
	var totalprice = (cash * tax) + cash;
    var totalstring = "";
	var month = 0;
	
	if ( isNaN(cash) == true || isNaN(tax) == true || isNaN(payment) == true){
		document.getElementById("demo").innerHTML = "<li> Please put in an int or floating point number </li> "
	}
	
    else {
	document.getElementById("demo").innerHTML = totalprice
	while (totalprice > 0){
        totalprice = totalprice - payment;
		month++;
		
		if(totalprice > 0){
		totalstring = totalstring +  ("<li> Month " + month + " your current balance is: " + totalprice + "$" + "</li>"); }
		
		else{
		totalstring = totalstring +  ("<li> Month " + month + " your current balance is: " + 0 + "$" + "</li>");}
		
		
	}
	totalstring = totalstring + "<li> You'll pay off your car in " + month + " months! </li>";
	// totalstring = totalstring + "</p>"
     document.getElementById("demo").innerHTML = totalstring;
	
}	
}

function isInt(x){
return x % 1 === 0;
}
