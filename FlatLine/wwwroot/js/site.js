const form = document.getElementById("ratingForm");
const error = document.querySelector(".error");
const success = document.querySelector(".success");

form.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent form from submitting normally

    // Get the email and rating inputs
    const email = document.getElementById("email").value.trim();
    const rating = document.querySelector('input[name="rating"]:checked');

    // Validate email
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email || !emailRegex.test(email)) {
        error.textContent = "Please enter a valid email address.";
        error.style.display = "block";
        success.style.display = "none";
        return;
    }

    // Validate rating
    if (!rating) {
        error.textContent = "Please select a rating before submitting.";
        error.style.display = "block";
        success.style.display = "none";
        return;
    }

    // If all validations pass
    error.style.display = "none";
    success.style.display = "block";
    console.log("Selected Rating:", rating.value);
    console.log("Entered Email:", email);
    
});