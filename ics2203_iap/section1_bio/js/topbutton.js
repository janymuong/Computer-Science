// SCT211-0848/2018 
// Jany Muong

function setupBackToTopButton() {
    const backBtn = document.getElementById("back-btn");
  
    window.addEventListener("scroll", () => {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        backBtn.style.display = "block";
      } else {
        backBtn.style.display = "none";
      }
    });

    backBtn.addEventListener("click", () => {
      document.body.scrollTop = 0; // for Safari
      document.documentElement.scrollTop = 0; // for Chrome, Firefox, Edge etc.
    });
  }

//   // Call the function to set up the Back to Top button
//   setupBackToTopButton();
  