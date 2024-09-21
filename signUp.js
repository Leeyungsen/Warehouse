async function addCategories(categoryName) {
    
    const name = $('#name').val();
    if (name.trim() === '') {
        displayError('name-error', 'Name is required');
        return;
    }

    const email = $('#email').val();
    if (!validateEmail(email)) {
        displayError('email-error', 'Please enter a valid Gmail address');
        return;
    }

    const password = $('#password').val();
    if (!validatePassword(password)) {
        displayError('password-error', 'Password must be at least 8 characters long and contain a number or symbol');
        return;
    }

    const confirmPassword = $('#confirm-password').val();
    if (password != confirmPassword) {
        displayError('confirm-password-error', 'Passwords do not match');
        return;
    }

    if (!$('#acceptTerms').is(':checked')) {
        displayError('terms-error', 'You must accept the terms and conditions');
        return;
    }

    $.ajax({
        url: 'https://localhost:5001/user/signup',
        method: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify({ categoryName }),
        success: async function (itemList) {
            console.log(itemList);
            await displayCategories();
        }
    });
}

function displayError(id, message) {
    $('#' + id).text(message);
}

function validateEmail(email) {
    const gmailRegex = /^[a-zA-Z0-9._%+-]+@gmail.com$/;
    return gmailRegex.test(email);
}

function validatePassword(password) {
    const passwordRegex = /^(?=.*[0-9!@#$%^&*])(?=.{8,})/;
    return passwordRegex.test(password);
}

$(document).ready(function () {
    $('#signup-form').submit(function (event) {
        event.preventDefault(); 
        addCategories(); 
    });
});
