// Add data
$.ajax({ 
	url: 'https://localhost:5001/category/addcategory', 
	method: 'POST', 
	success: function(response) { 
		const parsedData = JSON.parse(response); 
		// Process the parsed data here 
        console.log(parsedData);
	}, 
	error: function(xhr, status, error) { 
		// Handle any errors 
        console.error(error);
	} 
});

// menunjukan data
$.ajax({ 
	url: 'https://localhost:5001/category/getcategory', 
	method: 'GET', 
	success: function(response) { 
		const parsedData = JSON.parse(response); 
		// Process the parsed data here 
        console.log(parsedData);
	}, 
	error: function(xhr, status, error) { 
		// Handle any errors 
        console.error(error);
	} 
});

//  update category
$.ajax({ 
	url: 'https://localhost:5001/category/updatecategory', 
	method: 'PATCH', 
    contentType: 'application/json',
	success: function(response) { 
		const parsedData = JSON.parse(response); 
		// Process the parsed data here 
        console.log(parsedData);
	}, 
	error: function(xhr, status, error) { 
		// Handle any errors 
        console.error(error);
	} 
});

// delet category
$.ajax({ 
	url: 'https://localhost:5001/category/deletcategory', 
	method: 'DELETE', 
	success: function(response) { 
		// Process the parsed data here 
        console.log('Resource delete: ', response);
	}, 
	error: function(xhr, status, error) { 
		// Handle any errors 
        console.error(error);
	} 
});

//  User signup
$.ajax({
    url: 'https://localhost:5001/user/signup',
    method: 'POST',
    data: JSON.stringify(userData),
    contentType: 'application/json',
    success: function(response) {
        message.textContent = 'Signup successful!';
    },
    error: function(xhr, status, error) {
        message.textContent = 'Signup failed. Please try again later.';
    }
});

// User login
$.ajax({
    url: 'https://localhost:5001/user/login',
    method: 'POST',
    data: JSON.stringify(userData),
    contentType: 'application/json',
    success: function(response) {
        message.textContent = 'Login successful!';
    },
    error: function(xhr, status, error) {
        message.textContent = 'Login failed. Please check your credentials and try again.';
    }
});
