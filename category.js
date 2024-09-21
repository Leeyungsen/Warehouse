document.getElementById("add-category-button").addEventListener("click", function() {
    var categoryName = document.getElementById("Name").value;
    addCategories(categoryName);
});

// document.getElementById("btn-edit").addEventListener("click", function() {
//     var editName = document.getElementById("Name").value;
//     updateCategories(editName);
// });

displayCategories();
async function displayCategories() {
        await fetching();
            async function  fetching(){
                await $.ajax({ 
                url: 'https://localhost:5001/category/getcategory', 
                method: 'GET', 
                dataType: 'json',
                success: function(response) { 
                    console.log(response.data[0])
                    var result = response.data
                    console.log(result);

                    var itemList = ""
                    $.each(result, function(i, item) {
                        itemList += "<div class='category-item'> "  + item.categoryName + "  <div class='category-actions'><button class='btn-edit' id='edit-button' onClick = updateCategory(\"" + item.categoryId + "\")>Edit</button><button class='btn-delete' onClick = deleteCategory(\"" + item.categoryId + "\")>Delete</button></div></div>";
                });

                $(".category-list").html(itemList);
                }, 
                error: function(xhr, status, error) { 
                    // Handle any errors 
                    console.log(error);
                }
                });
            }
}

async function addCategories(categoryName) {
        $.ajax({ 
        url: 'https://localhost:5001/category/addcategory', 
        method: 'POST', 
        dataType: 'json',
        contentType : 'application/json',
        data: JSON.stringify({categoryName}),
        success : async function(itemList) { 
            console.log(itemList);
            await displayCategories();
        
        }
    });
}

async function updateCategory(categoryId) {

    var categoryName = document.getElementById("Name").value

    var input = {
        'categoryId'  : categoryId,
        'categoryName' : categoryName
    }

    $.ajax({ 
    url: 'https://localhost:5001/category/updatecategory', 
    method: 'PATCH', 
    dataType: 'json',
    contentType : 'application/json',
    data: JSON.stringify(input),
    success: async function(response) { 
        await displayCategories();
    } 
    });          
}

async function deleteCategory(categoryId) {


    var input = {
        'categoryId'  : categoryId,
        'categoryName' : ""
    }

    await $.ajax({ 
    url: 'https://localhost:5001/category/deletcategory', 
    method: 'DELETE', 
    dataType: 'json',
    contentType : 'application/json',
    data: JSON.stringify(input),
    success: async function(response) { 
        await displayCategories();
    } 
    });          
}