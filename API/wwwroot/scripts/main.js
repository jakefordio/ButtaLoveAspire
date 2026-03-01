// Your Vanilla JS logic for the ButtaLove SPA
document.addEventListener('DOMContentLoaded', () => {
    //initially, load home page
    loadPartial();
    //setup clicks/routing for all nav links/buttons
    const links = document.querySelectorAll('.link');
    //nav link/button routing
    links.forEach(link => link.addEventListener('click', (event) => {
        event.preventDefault();
        //the target page's href (url hash #value)
        let targetHash = event.target.getAttribute('href');
        loadPartial(targetHash);
    }));
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

//load partial views dynamically.. Home loads initially unless specified
async function loadPartial (targetHash = '/') {
    //window.onpopstate = () => handleRouting(window.location.pathname);

    //update address bar
    window.history.pushState({}, '', targetHash);
    loader.show();
    // Map the URL hash to your .NET Partial View endpoint
    const partial = targetHash === '/' ? 'home' : targetHash.substring(1);
    //fetch the target page's content
    const targetPartial = await fetch(`/content/${partial}`);
    if (!targetPartial.ok) throw new Error('Page not found');
    //get html for loading page, and container ready to render on
    const targetPartialHtml = await targetPartial.text();
    const container = document.querySelector('main#content');

    // Delay slightly for the transition effect
    setTimeout(() => {
        // 1. Inject the HTML
        container.innerHTML = targetPartialHtml;
        // 2. Manually find and run scripts marked with data-execute
        const scripts = container.querySelectorAll('script[data-execute="true"]');
        scripts.forEach(oldScript => {
            const newScript = document.createElement('script');
            // Copy attributes (especially type="module" if needed)
            Array.from(oldScript.attributes).forEach(attr => {
                newScript.setAttribute(attr.name, attr.value);
            });
            // Copy the actual code (the dynamic import logic)
            newScript.appendChild(document.createTextNode(oldScript.innerHTML));
            // Replace to trigger execution
            oldScript.parentNode.replaceChild(newScript, oldScript);
        });
        loader.hide();
    }, 400);
}
