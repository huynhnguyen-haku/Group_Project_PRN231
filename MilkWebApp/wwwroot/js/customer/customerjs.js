window.onload = function () {
    var header = document.querySelector(".header");
    var sticky = header.offsetHeight;

    window.onscroll = function () {
        if (window.scrollY > sticky - 100) {
            header.classList.add("sticky");
        } else {
            header.classList.remove("sticky");
        }
    }

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
}

// Upload image change
const btnUploadImg = document.getElementById('uploadBtnHidden');

const fileChosen = document.getElementById('file-chosen');

btnUploadImg.addEventListener('change', function () {
    fileChosen.textContent = this.files[0].name
})