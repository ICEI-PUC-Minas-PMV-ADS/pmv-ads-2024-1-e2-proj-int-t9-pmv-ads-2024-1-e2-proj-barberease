const initialPages = [...document.body.children].filter(
  (element) => element.id == "page"
);

window.navigation.addEventListener("navigate", () => {
  validateInitialPages();
  validateHomePages();
});

function validateInitialPages() {
  const actualPage = getActualPage();

  if (!actualPage) return;

  initialPages.forEach((page) => {
    const pageName = page.getAttribute("page-name");
    page.style.display = actualPage == pageName ? "block" : "none";
  });
}

function getActualPage() {
  const urlParams = new URLSearchParams(window.location.search);
  return urlParams.get("page");
}

function changeRoute(initialPage) {
  window.location.replace(`/src/frontend/index.html?page=${initialPage}`);
}

validateInitialPages();

if (window.location.pathname == "/index.html" && window.location.search == "")
  window.location.replace(`/index.html?page=pagina-inicial`);

