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

/*let sort_icon_switch = document.getElementById('sort-icon')

sort_icon_switch.onclick = () => {
    if (sort_icon_switch.classList.contains("sorted")) {
        sort_icon_switch.src = '../../media/arrow-down-short-wide-solid.svg'
        sort_icon_switch.classList.remove("sorted")
    }
    else {
        sort_icon_switch.src = '../../media/arrow-down-wide-short-solid.svg'
        sort_icon_switch.classList.add("sorted")
    }
}*/
