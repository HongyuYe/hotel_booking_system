const url = 'put_api_url_here';
//let transactions = [];
var present_card_ok = false;
var submitted = false;

//function getItems() {
//    fetch(url)
//        .then(response => response.json())
//        .then(data => _displayItems(data))
//        .catch(error => console.error('Unable to get items.', error));
//}

function amountModify(totalElement, amountElement) {
    var surcharge = 0.01 * parseFloat(amountElement.value);
    totalElement.value = surcharge + parseFloat(amountElement.value);
}

function addTransaction() {
    const addBookingNumberTextbox = document.getElementById('add-BookingNumber');
    const addFirstNameTextbox = document.getElementById('add-FirstName');
    const addLastNameTextbox = document.getElementById('add-LastName');
    const addEmailTextbox = document.getElementById('add-Email');
    const addPhoneNumberTextbox = document.getElementById('add-PhoneNumber');
    const addTotalTextbox = document.getElementById('add-Total');

    const item = {
        bookingNumber: addBookingNumberTextbox.value.trim(),
        firstName: addFirstNameTextbox.value.trim(),
        lastName: addLastNameTextbox.value.trim(),
        email: addEmailTextbox.value.trim(),
        phoneNumber: addPhoneNumberTextbox.value.trim(),
        total: parseFloat(addTotalTextbox.value),
        paid: false,
        cardDetected: false,
        deposit: false
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
            //getItems();
            //addNameTextbox.value = '';
            if (parseFloat(addTotalTextbox.value) == 0) {
                var go_deposit_ok = false;
                while (go_deposit_ok == false) {
                    var go_deposit = confirm('Thank you! Please click OK to continue.');
                    if (go_deposit) {
                        go_deposit_ok = true;
                        //keepValues();
                        window.location.href = 'deposit.html';
                    }
                }
            } else {
                submitted = true;
                var present_card = confirm('Thank you! Please proceed this payment by presenting your card to the card reader on the table. Click OK after presenting card. Click Cancel to cancel this transaction.');
                if (present_card) {
                    setTimeout(function () { present_card_ok = true; }, 5000);
                } else {
                    cancelTransaction();
                }
            }
        })
        .catch(error => {
            console.error('Unable to add item.', error);
            var submit_error = confirm('Sorry, unable to submit this form. Please check the Internet connection.');
        });
}


//function keepValues(){
//    const addBookingNumberTextbox = document.getElementById('add-BookingNumber');
//    const addFirstNameTextbox = document.getElementById('add-FirstName');
//    const addLastNameTextbox = document.getElementById('add-LastName');
//    const addEmailTextbox = document.getElementById('add-Email');
//    const addPhoneNumberTextbox = document.getElementById('add-PhoneNumber');

//    localStorage.setItem("booking_Number", addBookingNumberTextbox.value.trim());
//    localStorage.setItem("first_Name", addFirstNameTextbox.value.trim());
//    localStorage.setItem("last_Name", addLastNameTextbox.value.trim());
//    localStorage.setItem("_Email", addEmailTextbox.value.trim());
//    localStorage.setItem("phone_Number", addPhoneNumberTextbox.value.trim());
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
            window.location.reload();
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
                    var go_deposit_ok = false;
                    while (go_deposit_ok == false) {
                        var go_deposit = confirm('Thank you! Payment was successful. Please click OK to continue.');
                        if (go_deposit) {
                            go_deposit_ok = true;
                            //keepValues();
                            window.location.href = 'deposit.html';
                        }
                    }
                } else if (lastItem.paid == false && lastItem.cardDetected == true && present_card_ok == true) {
                    present_card_ok = false;
                    submitted = false;
                    var pay_again = confirm('Sorry, payment was unsuccessful. Please click Pay Now button on this page to try again.');
                } else if (lastItem.paid == false && lastItem.cardDetected == false && present_card_ok == true) {
                    present_card_ok = false;
                    var present_again_cancel = false;
                    while (present_card_ok == false && present_again_cancel == false) {
                        var present_again = confirm('Sorry, no card detected. Please present your card again. Click OK after presenting card. If the card reader is not responding, please click Cancel and click Pay Now button on this page to try again.');
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
}, 1000);


setTimeout(function () {
    if (submitted == true) {
        submitted = false;
        window.location.reload();
    }
}, 300000);


//function change_cardDetected(item) {
//    item.cardDetected = false;
//    fetch(`${url}/${item.transactionId}`, {
//        method: 'PUT',
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(item)
//    })
//    .catch(error => console.error('Unable to update item.', error));
//}


//$.ajax({
//    url,
//    type: 'GET',
//    dataType: 'json', // Returns JSON
//    success: function (response) {
//        $('#tabela-alunos td').remove("");
//        $('#info p').remove();
//        var sTxt = '';
//        $.each(response, function (index, val) {
//            sTxt += '<tr>';
//            sTxt += '<td>' + val.id + '</td>';
//            sTxt += '<td>' + val.nome + '</td>';
//            sTxt += '<td>' + val.ra + '</td>';
//            sTxt += '<td>' + val.curso + '</td>';
//            sTxt += '<td>' + val.periodo + '</td>';
//            sTxt += '<td>' + val.nota + '</td>';
//            sTxt += '<td>' + ValidaStatus(val.nota) + '</td>';

//            sTxt += '</tr>';
//        });
//        $('#tabela-alunos').append(sTxt);
//    },
//    error: function () {
//        $('#info').html('<p>Ocorreu um erro, verifique a conexão com a api!</p>');
//    }
//});

//function deleteItem(id) {
//    fetch(`${url}/${id}`, {
//        method: 'DELETE'
//    })
//        .then(() => getItems())
//        .catch(error => console.error('Unable to delete item.', error));
//}

//function displayEditForm(id) {
//    const item = todos.find(item => item.id === id);

//    document.getElementById('edit-name').value = item.name;
//    document.getElementById('edit-id').value = item.id;
//    document.getElementById('edit-isComplete').checked = item.isComplete;
//    document.getElementById('editForm').style.display = 'block';
//}

//function closeInput() {
//    document.getElementById('editForm').style.display = 'none';
//}

//function _displayCount(itemCount) {
//    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

//    document.getElementById('counter').innerText = `${itemCount} ${name}`;
//}

//function _displayItems(data) {
//    const tBody = document.getElementById('todos');
//    tBody.innerHTML = '';

//    _displayCount(data.length);

//    const button = document.createElement('button');

//    data.forEach(item => {
//        let isCompleteCheckbox = document.createElement('input');
//        isCompleteCheckbox.type = 'checkbox';
//        isCompleteCheckbox.disabled = true;
//        isCompleteCheckbox.checked = item.isComplete;

//        let editButton = button.cloneNode(false);
//        editButton.innerText = 'Edit';
//        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

//        let deleteButton = button.cloneNode(false);
//        deleteButton.innerText = 'Delete';
//        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

//        let tr = tBody.insertRow();

//        let td1 = tr.insertCell(0);
//        td1.appendChild(isCompleteCheckbox);

//        let td2 = tr.insertCell(1);
//        let textNode = document.createTextNode(item.name);
//        td2.appendChild(textNode);

//        let td3 = tr.insertCell(2);
//        td3.appendChild(editButton);

//        let td4 = tr.insertCell(3);
//        td4.appendChild(deleteButton);
//    });

//    todos = data;
//}