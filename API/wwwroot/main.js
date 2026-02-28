// Your Vanilla JS logic for the ButtaLove SPA
let pageContent;
document.addEventListener('DOMContentLoaded', () => {
    pageContent = document.querySelector('main#content');
    window.location.hash = '#home';
    //add click events for all nav items
    document.addEventListener('click', navigate);
    window.addEventListener('hashchange', navigate)
});

const loader = {
    element: document.getElementById('loading_overlay'),
    show() {
        this.element.classList.remove('d-none');
    },
    hide() {
        this.element.classList.add('d-none');
    }
};

const navigate = async (event) => {

    event.preventDefault();
    let urlHash = '';
    if (event.type === 'hashchange') {
        urlHash = window.location.hash;
    } else if (event.type === 'click' && event.target.classList.contains('link')) {
        if (event.target.tagName === 'BUTTON') {
            urlHash = event.target.dataset.hash;
        }
        if (event.target.tagName === 'A') {
            urlHash = event.target.hash;
        }
        if (urlHash === '') {
            urlHash = '#home';
        }
    } else {
        return false;
    }
    //update address bar
    window.history.pushState({}, '', urlHash);

    //fetch and display new content
    await handleRouting(urlHash);
}

// 6. The Routing & Fetch Logic
async function handleRouting(urlHash) {
    // Show transition/loading state
    loader.show();

    // Map the URL hash to your .NET Partial View endpoint
    // e.g., /products -> /content/Products
    const pageName = urlHash === '' ? 'home' : urlHash.substring(1);

    try {
        const response = await fetch(`/content/${pageName}`);
        if (!response.ok) throw new Error('Page not found');

        const html = await response.text();

        // Delay slightly for the transition effect
        setTimeout(() => {
            pageContent.innerHTML = html;
            loader.hide();
        }, 300);
    } catch (err) {
        pageContent.innerHTML = '<div class="alert alert-danger">Error loading content.</div>';
        pageContent.classList.remove('loading');
    }
}

// 7. Handle browser Back/Forward buttons
window.onpopstate = () => handleRouting(window.location.pathname);