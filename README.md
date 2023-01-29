# booking_system
The guest who enters the hotel can type in their details of booking on a web page (or someone else can enter the details for the guest remotely) and pay with an EFPOS machine which is connected with the Windows system. The system needs to confirm the payment and generate the receipts, also to inform both parties by emails.

 









System Description For Windsor Payment System







Document Version: 2.0

Date: 21/01/2021
 
1
OVERVIEW
A booking system connected with EFPOS payment system.

1.1Service Description
The guest who enters the hotel can type in their details of booking on a web page(or someone else can enter the details for the guest remotely) and pay with an EFPOS machine which is connected with the Windows system.

1.2Technology and Development Tools
Developed with Microsoft Visual Studio 2019, using C#, Javascript, HTML. 



1.3Interfaces and services
1.3.1The web pages

Link: https://thewindsorpayment.azurewebsites.net




Link: https://thewindsorpayment.azurewebsites.net/deposit.html


These are the user interface for the guests, they can enter their name and Email,phone number, booking number, also the amount they’re going to pay, then they will be able to proceed the payment by presenting their banking card to the card reader on the table (the web page will prompt them to do so, the web page will also prompt the user if the payment declined and card not detected with the next step to redo the payment). If the payment was successful, the page will prompt them with the next step. The user can press the Cancel Transaction button on the bottom to cancel the transaction.
Once the payment is successful, both the guest and the administrator will receive an auto-generated recipt in their email account from the administrator’s email address. If some customers don't have an email or don't want to receive receipt in email, they can leave the email field empty. In the cases payment declined and card not detected, no email will be sent.There is a dedicated administrator’s email account to receive the receipts, any past record can be searched inside the email account. All the data entered will be sent to server and receiced by the Windows desktop program to process the payment.


Payment receipt email:


Deposit receipt email:


Booking and paid somewhere else email (system send this email if the user enters 0 in the Payment Amount filed on the web page for booking only):


Link: https://thewindsorpayment.azurewebsites.net/confirmNrefundxxxxx.html


This is the page used by the administrator to refund and comfirm pre-authorised payment, the address should not be showed to the public.
After the refund and confirmation, there is no feedback will come back from the system. Administrator will need to check the status in TMS.

Note: we need to send email to card reader company to clarify this.  The system doesn't provide me the full reference number which is required to refund and confirm, I don't know it's because it's in test mode or it's always like that.  If it's the system requirement to keep the reference number secret, then we can only refund and confirm the last pre-authorised transaction, on the web page and the windows program. (The windows program they provided also can only do the last transaction).

Source code:
The source code of the web pages is under project directory: 
booking_system\TheWindsorAPI\TheWindsorAPI\wwwroot 

The email auto-generating code is inside the file: booking_system\MainForm.cs


1.3.2The card reader
Once the guest entered their details and payment amount can tabbed the Pay Now button on the web page, then the card reader will display the payment amount and prompt them to present card: 


After the guest presenting their card, the card reader displays the payment status, if it shows Approved, the payment is successful, if it shows something else, then the guest needs to tab the Pay Now button on the web page again to redo it.
The user can press the yellow button on the card reader to cancel the transaction anytime.


1.3.3The desktop program


This is the user interface of the desktop program which is installed on a Windows device, the program communicates with the card reader to pass the due payment amount which entered on the web page from the server to the card reader and process the payment status data.
This interface is not for the guests, it is for the administration of the system and it allows the developers to test the functions, it also displays the information and responses from the system for the developers. The auto-generated recipt emails are created from this program. The administrator’s email which is used to send and receive auto-generated recipt can be set in this windows desktop program’s interface.

Note: Before using this program the card reader Windows PC driver(in the same folder with this doc) should be installed in the same Windows computer.  Every time before starting this program, connect the Telebox with the Windows computer and open the web page anywhere remotely or locally: https://thewindsorpayment.azurewebsites.net/

The main source code of the web page is under project directory:  
booking_system\MainForm.cs

1.3.4The Web API
The Web Api doesn’t have an actual visual interface. It is the logic of the system’s backend, server and database. It handled the backend data communications between the web page, the server and the desktop program. In order to keep lower costs and for security reason, the in-memory database is used with this web API, which means every time it restarts, the data contain user’s personal information will be gone. But there is a dedicated administrator’s email account to receive the receipts, any past record can be searched inside the email account.

The source codes of the web API is under the project directory:  
booking_system\TheWindsorAPI


URL: https://thewindsorpayment.azurewebsites.net/api/transactions
https://thewindsorpayment.azurewebsites.net/api/refunds


2Support details

2.1Third Party
The Card Access Services (cardaccess.com.au) provided the SDK and major source codes of the Windows desktop program and support of the EFPOS payment system.


2.2Troubleshooting Guide

Regarding the EFPOS payment system questions and documentations, please send email to: sebm@vendaccess.com.au  or astanford@cardaccess.com.au
 





3Recommendations for improvement
Add user entry validation, fixing the auto refresh of the page which is not working, use socket rather than timer in the codes, add database(maximum. 100 transactions per day for 2 years = 73000 transactions to keep in the database), add comments to the codes, add authentication support to a web API 2.1 to improve security(https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#add-authentication-support-to-a-web-api-21), more functions...

、
