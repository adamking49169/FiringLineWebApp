// Smooth-scroll offsets for sticky header
document.addEventListener("click", (e) => {
    const a = e.target.closest('a[href^="#"]');
    if (!a) return;

    const id = a.getAttribute("href");
    if (!id || id === "#") return;

    const el = document.querySelector(id);
    if (!el) return;

    e.preventDefault();
    const header = document.querySelector(".site-header");
    const offset = (header?.offsetHeight ?? 0) + 12;

    const top = el.getBoundingClientRect().top + window.scrollY - offset;
    window.scrollTo({ top, behavior: "smooth" });
});
document.addEventListener("DOMContentLoaded", () => {
    const carouselEl = document.querySelector("#heroCarousel");
    if (!carouselEl) return;

    const bootstrap = window.bootstrap;
    if (!bootstrap?.Carousel) return;

    bootstrap.Carousel.getOrCreateInstance(carouselEl, {
        interval: 3000,
        ride: "carousel"
    });
});