document.addEventListener('DOMContentLoaded', () => {
    console.log('Error Testing page loaded');
    //Bad Request
    document.querySelector("button#400").addEventListener("click", error)
});

const error = (event) => {
    const statusCode = parseInt(event.target.id);
    fetch('http://localhost:10001/test/errors', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        //which http status code are we testing
        body: JSON.stringify({
            code: parseInt(statusCode)
        })
    })
        .then(async response => {
            if (response.status === statusCode) {
                const errorData = await response.json();
                toastr.success(`${response.status}: ${response.statusText} resulting as expected`, errorData);
            } else {
                toastr.error(`${response.status}: ${response.statusText} gave an unexpected result`);
            }
        })
        .catch(error => {
            console.error('Fetch error:', error);
        });
}