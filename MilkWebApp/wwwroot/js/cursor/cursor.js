document.addEventListener('DOMContentLoaded', (event) => {
    const cursor = document.getElementById('cursor');
    const allElements = document.querySelectorAll('*');

    allElements.forEach(elem => {
        elem.addEventListener('mouseover', () => {
            if (['P', 'SPAN', 'H1', 'H2', 'H3', 'H4', 'H5', 'H6'].includes(elem.nodeName)) {
                cursor.classList.add('expand');
            } else {
                cursor.classList.add('hover');
            }
        });

        elem.addEventListener('mouseout', () => {
            cursor.classList.remove('hover', 'expand');
        });
    });

    document.addEventListener('mousemove', e => {
        cursor.setAttribute("style", "top: " + (e.pageY - 10) + "px; left: " + (e.pageX - 10) + "px;")
    })
});