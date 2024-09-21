const Email = document.getElementById('email');
const Password = document.getElementById('password');

document.addEventListener('DOMContentLoaded', function() {
    const loginForm = document.getElementById('login-form');
    const message = document.getElementById('message');

    loginForm.addEventListener('submit', function(event) {
        event.preventDefault();

        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;

        // Clear any previous error messages
        clearErrors();

        // Client-side validation
        let valid = true;

        if (!email) {
            displayError('email-error', 'Please enter your email address.');
            valid = false;
        } else if (!isValidEmail(email)) {
            displayError('email-error', 'Please enter a valid email address.');
            valid = false;
        }

        if (!password) {
            displayError('password-error', 'Please enter your password.');
            valid = false;
        }

        if (valid) {
            // You can check the provided email and password against your user database
            // For this example, we'll use a placeholder
            if (email === 'user@example.com' && password === 'password123') {
                message.textContent = 'Login successful! Redirecting to menu...';

                // Automatically redirect to the menu page after a brief delay
                setTimeout(function() {
                    window.location.href = 'index.html'; // Replace with your menu page URL
                }, 2000); // Redirect after 2 seconds (adjust as needed)
            } else {
                message.textContent = 'Login failed. Please check your email and password.';
            }
        }
        $.ajax({
            url: 'https://localhost:5001/user/login', // Match this URL with your server route
            method: 'POST',
            data: JSON.stringify({ email, password }),
            contentType: 'application/json',
            success: function(response) {
                // Handle a successful login here
                console.log('Login successful', response);
            },
            error: function(xhr, status, error) {
                // Handle login error
                console.log('Login error', error);
            }
        });
    });

    // Helper function to clear error messages
    function clearErrors() {
        const errorElements = document.getElementsByClassName('error');
        for (let i = 0; i < errorElements.length; i++) {
            errorElements[i].textContent = '';
        }
    }

    // Helper function to display an error message
    function displayError(id, message) {
        const errorElement = document.getElementById(id);
        errorElement.textContent = message;
    }

    // Helper function to validate email format
    function isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }
});


