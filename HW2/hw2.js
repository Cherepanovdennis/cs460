// JavaScript source codefunction myFunction() {


function testfunction() {
    var cash = parseFloat($("#datacost").val()); //convert input to float
    var tax = parseFloat($("#datasale").val()); //convert input to float
    var payment = parseFloat($("#datapayment").val());
	var totalprice = (cash * tax) + cash;
    var totalstring = "";
	var month = 0;
	
	if ( isNaN(cash) == true || isNaN(tax) == true || isNaN(payment) == true){
	$("#demo").html("<li> Please put in an int or floating point number </li>");
	}
	
	else if (cash == 0 ){
	$("#demo").html("Free car!");}
	
	else if (payment == 0) {
		$("#demo").html("You'll never pay off your car, better start job hunting");
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
     $("#demo").html(totalstring);
	
}	
}

function isInt(x){
return x % 1 === 0;
}
