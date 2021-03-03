const url = 'put_api_url_here';
//let transactions = [];
var present_card_ok = false;
var submitted = false;

window.onload = function () {
    //getValues();
    fetch(url)
        .then(response => response.json())
        .then(data => {
            var lastItem = data[data.length - 1];
            if (lastItem.email != 'ujsvjdjvfs@protonmail.com') {
                document.getElementById('add-BookingNumber').value = lastItem.bookingNumber;
                document.getElementById('add-FirstName').value = lastItem.firstName;
                document.getElementById('add-LastName').value = lastItem.lastName;
                document.getElementById('add-Email').value = lastItem.email;
                document.getElementById('add-PhoneNumber').value = lastItem.phoneNumber;
            }
        })
        .catch(error => {
            console.error('Unable to get items.', error);
            var get_status_error = confirm('Sorry, unable to get the previous form data. Please check the Internet connection or enter your detials manually.');
        });
}

function amountModify(totalElement, amountElement) {
    totalElement.value = amountElement.value;
}

function addTransaction() {
    const addBookingNumberTextbox = document.getElementById('add-BookingNumber');
    const addFirstNameTextbox = document.getElementById('add-FirstName');
    const addLastNameTextbox = document.getElementById('add-LastName');
    const addEmailTextbox = document.getElementById('add-Email');
    const addPhoneNumberTextbox = document.getElementById('add-PhoneNumber');
    const addTotalTextbox = document.getElementById('add-Total');

    if (parseFloat(addTotalTextbox.value) == 0) {
        var go_back = confirm('Thank you! All done.');
        if (go_back) {
            window.location.href = 'index.html';
        } else {
            window.location.href = 'index.html';
        }
    } else {
        const item = {
            bookingNumber: addBookingNumberTextbox.value.trim(),
            firstName: addFirstNameTextbox.value.trim(),
            lastName: addLastNameTextbox.value.trim(),
            email: addEmailTextbox.value.trim(),
            phoneNumber: addPhoneNumberTextbox.value.trim(),
            total: parseFloat(addTotalTextbox.value),
            paid: false,
            cardDetected: false,
            deposit: true
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
            .then(response => response.json())
            .then(() => {
                submitted = true;
                var present_card = confirm('Thank you! Please proceed this payment by presenting your card to the card reader on the table. Click OK after presenting card. Click Cancel to cancel this transaction.');
                if (present_card) {
                    setTimeout(function () { present_card_ok = true; }, 5000);
                } else {
                    cancelTransaction();
                }
            })
            .catch(error => {
                console.error('Unable to add item.', error);
                var submit_error = confirm('Sorry, unable to submit this form. Please check the Internet connection.');
            });
    }
}

//function getValues() {
//    document.getElementById("add-BookingNumber").innerHTML = localStorage.getItem("booking_Number");
//    document.getElementById("add-FirstName").innerHTML = localStorage.getItem("first_Name");
//    document.getElementById("add-LastName").innerHTML = localStorage.getItem("last_Name");
//    document.getElementById("add-Email").innerHTML = localStorage.getItem("_Email");
//    document.getElementById("add-PhoneNumber").innerHTML = localStorage.getItem("phone_Number");
//}


function cancelTransaction() {
    if (submitted == true) {
        setTimeout(function () {
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    var lastItem = data[data.length - 1];
                    if (lastItem.cancel != true) {
                        lastItem.cancel = true;
                        fetch(url + '/' + String(lastItem.transactionId), {
                            method: 'PUT',
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(lastItem)
                        })
                            .catch(error => {
                                console.error('Unable to update item.', error);
                                //var update_error = confirm('Sorry, unable to submit request. Please check the Internet connection.');
                            });
                    }
                })
                .catch(error => {
                    console.error('Unable to get items.', error);
                    var get_status_error = confirm('Sorry, unable to get the payment status. Please press the yellow button on the card reader to cancel the transaction.');
                });
            submitted = false;
            var stay_or_not = confirm('To stay in this page, click OK. To go back to previous page, click Cancel.');
            if (stay_or_not) { } else { window.location.href = 'index.html'; }
        }, 3000);
    }
}


setInterval(function () {
    if (submitted == true) {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                var lastItem = data[data.length - 1];
                if (lastItem.paid == true && lastItem.cardDetected == true && present_card_ok == true) {
                    present_card_ok = false;
                    submitted = false;
                    var go_back2 = confirm('Thank you! Payment was successful. All done.');
                    if (go_back2) {
                        window.location.href = 'index.html';
                    } else {
                        window.location.href = 'index.html';
                    }
                } else if (lastItem.paid == false && lastItem.cardDetected == true && present_card_ok == true) {
                    present_card_ok = false;
                    submitted = false;
                    var pay_again = confirm('Sorry, payment was unsuccessful. Please click Deposit button on this page to try again.');
                } else if (lastItem.paid == false && lastItem.cardDetected == false && present_card_ok == true) {
                    present_card_ok = false;
                    var present_again_cancel = false;
                    while (present_card_ok == false && present_again_cancel == false) {
                        var present_again = confirm('Sorry, no card detected. Please present your card again. Click OK after presenting card. If the card reader is not responding, please click Cancel and click Deposit button on this page to try again.');
                        if (present_again) {
                            present_card_ok = true;
                        } else {
                            present_again_cancel = true;
                            cancelTransaction();
                            submitted = false;
                        }
                    }
                }
            })
            .catch(error => {
                console.error('Unable to get items.', error);
                var get_status_error = confirm('Sorry, unable to get the payment status. Please check the Internet connection.');
            });
    }
}, 500);

setTimeout(function () {
    window.location.href = 'index.html';
}, 300000);