// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

changeMarkStatusColor = () => {
    const mark_status = document.querySelectorAll('.mark__list-status')
    mark_status.forEach((element) => {
        switch (element.textContent) {
            case 'completed':
                element.classList.add('completed');
                break;
            case 'not_graded':
                element.classList.add('evaluating');
                break;
            case 'failed':
                element.classList.add('failed');
                break;
            default:
                break;
        }
    })
}
changeMarkStatusColor()

