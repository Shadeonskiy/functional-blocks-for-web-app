let calendar = document.querySelector('.calendar')

const month_names = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']
const year_numbers = [2018,2019,2020,2021,2022,2023,2024,2025,2026]

isLeapYear = (year) => {
    return (year % 4 === 0 && year % 100 !== 0 && year % 400 !== 0) || (year % 100 === 0 && year % 400 ===0)
}

getFebDays = (year) => {
    return isLeapYear(year) ? 29 : 28
}

generateCalendar = (month, year) => {

    let calendar_days = calendar.querySelector('.calendar-days')
    let calendar_header_year = calendar.querySelector('#year')

    let days_of_month = [31, getFebDays(year), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]

    calendar_days.innerHTML = ''

    let currDate = new Date()
    if (month == null) month = currDate.getMonth()
    if (year == null) year = currDate.getFullYear()
    let curr_month = `${month_names[month]}`
    month_picker.innerHTML = curr_month
    calendar_header_year.innerHTML = year

    // get first day of month
    
    let first_day = new Date(year, month, 1)

    for (let i = 0; i <= days_of_month[month] + first_day.getDay() - 1; i++) {
        let day = document.createElement('div')
        if (i >= first_day.getDay()) {
            day.classList.add('calendar-day-hover')
            day.innerHTML = i - first_day.getDay() + 1
            day.innerHTML += `<span></span>
                            <span></span>
                            <span></span>
                            <span></span>`
            if (i - first_day.getDay() + 1 === currDate.getDate() && year === currDate.getFullYear() && month === currDate.getMonth()) {
                day.classList.add('curr-date')
            }
        }
        calendar_days.appendChild(day)
    }
}

let month_list = calendar.querySelector('.month-list')

month_names.forEach((e, index) => {
    let month = document.createElement('div')
    month.innerHTML = `<div data-month="${index}">${e}</div>`
    month.querySelector('div').onclick = () => {
        month_list.classList.remove('show')
        curr_month.value = index
        generateCalendar(curr_month.value, curr_year.value)
    }
    month_list.appendChild(month)
})

let month_picker = calendar.querySelector('#month-picker')

month_picker.onclick = () => {
    month_list.classList.add('show')
}

let year_list = calendar.querySelector('.year-list')

year_numbers.forEach((e, index) => {
    let year = document.createElement('div')
    year.innerHTML = `<div data-year="${index}">${e}</div>`
    year.querySelector('div').onclick = () => {
        year_list.classList.remove('show')
        year_picker.innerHTML = year_numbers[index]
        curr_year.value = year_numbers[index]
        generateCalendar(curr_month.value, curr_year.value)
    }
    year_list.appendChild(year)
})

let year_picker = calendar.querySelector('#year-picker')

year_picker.onclick = () => {
    year_list.classList.add('show')
}

let currDate = new Date()

let curr_month = {value: currDate.getMonth()}
let curr_year = {value: currDate.getFullYear()}

generateCalendar(curr_month.value, curr_year.value)

// document.querySelector('#prev-year').onclick = () => {
//     --curr_year.value
//     generateCalendar(curr_month.value, curr_year.value)
// }

// document.querySelector('#next-year').onclick = () => {
//     ++curr_year.value
//     generateCalendar(curr_month.value, curr_year.value)
// }

document.querySelector('#prev-month').onclick = () => {
    --curr_month.value;
    if(curr_month.value === -1){
        curr_month.value = 11;
        --curr_year.value;
    }
    generateCalendar(curr_month.value, curr_year.value)
}

document.querySelector('#next-month').onclick = () => {
    ++curr_month.value;
    if(curr_month.value === 12){
        curr_month.value = 0;
        ++curr_year.value;
    }
    generateCalendar(curr_month.value, curr_year.value)
}

let dark_mode_toggle = document.querySelector('.dark-mode-switch')

dark_mode_toggle.onclick = () => {
    document.querySelector('.calendar').classList.toggle('light')
    document.querySelector('.calendar').classList.toggle('dark')
}