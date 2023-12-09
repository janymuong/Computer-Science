document.addEventListener('DOMContentLoaded', function () {
    // JavaScript function - render the form on blog.html
    function renderForm() {
        const formContainer = document.getElementById('form-container');

        // create form element;
        const form = document.createElement('form');
        form.className = 'aboutleft';

        // gender radio buttons;
        const genderLabel = document.createElement("p");
        genderLabel.textContent = "Please select your gender (not relevant for the blog search):";
        form.appendChild(genderLabel);

        const genderLabels = ['Male', 'Female', 'Other'];
        genderLabels.forEach(function (gender) {
            const label = document.createElement("label");
            label.className = "label";

            const input = document.createElement("input");
            input.type = "radio";
            input.name = "gender";
            input.value = gender.toLowerCase();

            label.appendChild(input);
            label.appendChild(document.createTextNode(gender));
            form.appendChild(label);
        });

        form.appendChild(document.createElement("br"));
        form.appendChild(document.createElement("br"));

        // blog background dropdown;
        const blogLabel = document.createElement("span");
        blogLabel.textContent = "Please select blogs's background: ";
        form.appendChild(blogLabel);

        const dropdown = document.createElement("select");
        dropdown.name = "field";
        dropdown.id = "dropdown";

        const blogOptions = ["Computer science", "YouTube", "Jokes", "No filters"];
        blogOptions.forEach(function (optionText) {
            const option = document.createElement("option");
            option.value = optionText.toLowerCase();
            option.textContent = optionText;
            dropdown.appendChild(option);
        });

        form.appendChild(dropdown);
        form.appendChild(document.createElement("br"));

        // Add search inputs
        const searchInput = document.createElement("input");
        searchInput.className = "search";
        searchInput.type = "search";
        searchInput.placeholder = "Enter term to look up";
        form.appendChild(searchInput);

        const submitInput = document.createElement("input");
        submitInput.className = "search";
        submitInput.type = "submit";
        submitInput.value = "Search in-blogs";
        form.appendChild(submitInput);

        // append form to html (div) container;
        formContainer.appendChild(form);
    }

    renderForm();
});
