$(document).ready(function () {

    $('#update-form').validate({
        rules: {
            Name: "required",
            Description: {
                required: true,
            },
            IsActive: {
                required: true,
            },
            ShopEmaill: {
                required: true,
                email: true,
            },
            ShopAddress:{
                required: true,
            },
            ShopTelephoneNumber: {
                required: true,
                minlength: 10,
                number: true,
            }
        },
        messages: {
            Name: "Please Enter Shop Name",
            Description: {
                required: "Please Enter Description",
              

            },
            IsActive: {
                required: "Please Provide a Passord",

            },
            ShopEmaill: {
                required: "Please Provide a Email",
                email : "Please enter a valid email address"

            },
            ShopAddress: {
                required: "Please Enter Shop Address",
            },
            ShopTelephoneNumber: {
                required: "Pleses Enter Telephone Number",
                minlength: "Plese Enter Valid Telephone Number",
                number: "Plese Enter Valid Telephone Number",

            }
     

        }

    })
});