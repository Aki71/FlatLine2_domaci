// Renaming to avoid conflict
const ratingForm = document.getElementById("ratingForm");
const errorMessage = document.querySelector(".error");  // Renamed from 'error'
const successMessage = document.querySelector(".success");  // Renamed from 'success'

ratingForm.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent form from submitting normally

    // Get the email and rating inputs
    const email = document.getElementById("email").value.trim();
    const rating = document.querySelector('input[name="rating"]:checked');

    // Validate email
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email || !emailRegex.test(email)) {
        errorMessage.textContent = "Please enter a valid email address.";
        errorMessage.style.display = "block";
        successMessage.style.display = "none";
        return;
    }

    // Validate rating
    if (!rating) {
        errorMessage.textContent = "Please select a rating before submitting.";
        errorMessage.style.display = "block";
        successMessage.style.display = "none";
        return;
    }

    // If all validations pass
    errorMessage.style.display = "none";
    successMessage.style.display = "block";
    console.log("Selected Rating:", rating.value);
    console.log("Entered Email:", email);

    // Clear the form fields
    ratingForm.reset();

    // Reset radio buttons (this is often necessary)
    const radioButtons = ratingForm.querySelectorAll('input[type="radio"]');
    radioButtons.forEach(radio => radio.checked = false);

    // Optionally, reset success message after a short delay (to allow user to see it)
    setTimeout(() => {
        successMessage.style.display = "none";
    }, 3000);  // Hide success message after 3 seconds
});
