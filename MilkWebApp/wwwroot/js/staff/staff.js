document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('#item-orders .arrow').addEventListener('click', function () {
        document.querySelector('#item-orders').classList.toggle('open');
    });
});