const initialPages = [...document.body.children].filter(
  (element) => element.id == "page"
);

const homePages = document.body
  .querySelector('[page-name="home"]')
  .querySelectorAll("#page");

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

function validateHomePages() {
  const actualPage = getActualPage();

  if (actualPage != "home") {
    homePages.forEach((page) => {
      page.style.display = "none";
    });
    return;
  }

  const secondPage = getSecondPage();

  homePages.forEach((page) => {
    const pageName = page.getAttribute("page-name");

    page.style.display = secondPage == pageName ? "block" : "none";
  });
}

function getActualPage() {
  const urlParams = new URLSearchParams(window.location.search);
  return urlParams.get("page");
}

function getSecondPage() {
  const urlParams = new URLSearchParams(window.location.search);
  return urlParams.get("second-page");
}

function changeRoute(initialPage, secondPage) {
  if (secondPage) {
    window.location.replace(
      `/src/project/index.html?page=${initialPage}&second-page=${secondPage}`
    );
    return;
  }

  window.location.replace(`/src/project/index.html?page=${initialPage}`);
}

validateInitialPages();
validateHomePages();
