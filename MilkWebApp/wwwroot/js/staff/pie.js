document.addEventListener('DOMContentLoaded', (event) => {
    const ctx = document.getElementById('catesale');

    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ["Lion", "Horse", "Elephant", "Tiger", "Jaguar"],
            datasets: [{
                backgroundColor: ["#51EAEA", "#FCDDB0", "#FF9D76", "#FB3569", "#82CD47"],
                data: [418, 263, 434, 586, 332]
            }]
        },
        options: {
            title: {
                display: true,
                text: 'Chart JS Pie Chart Example'
            }
        }
    });
});