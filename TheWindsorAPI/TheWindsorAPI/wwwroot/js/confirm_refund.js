const url = 'put_api_url_here';

function addTransaction(form) {
    const addReferenceNumberTextbox = document.getElementById('add-ReferenceNumber');
    const addAmountTextbox = document.getElementById('add-Amount');

    var item = {
        reference: '0',
        isRefund: false,
        amount: '0'
    };
    if (document.activeElement.value == 'Refund') {
        item = {
            reference: addReferenceNumberTextbox.value.trim(),
            isRefund: true,
            amount: '0'
        };
    } else {
        item = {
            reference: addReferenceNumberTextbox.value.trim(),
            isRefund: false,
            amount: addAmountTextbox.value
        };
    }

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
            if (document.activeElement.value == 'Refund') {
                var sbumit_ok = confirm('Kiosk administrator can check the status of voided transactions in TMS when searching for ‘Cancel’ and ‘Cancel Declined’');
            } else {
                var sbumit_ok = confirm('Kiosk administrator can check the status of confirmed transactions in TMS when searching for ‘Confirm’ and ‘Confirm Declined’');
            }
        })
        .catch(error => {
            console.error('Unable to add item.', error);
            var submit_error = confirm('Sorry, unable to submit the form. Please check the Internet connection.');
        });
}