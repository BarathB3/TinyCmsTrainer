document.addEventListener("DOMContentLoaded", function () {
    const toggle = document.getElementById("themeToggle");
    const body = document.body;

    // Alapértelmezett téma: világos
    body.classList.add("light-theme");

    toggle.addEventListener("click", function () {
        body.classList.toggle("dark-theme");
        body.classList.toggle("light-theme");
    });
});
