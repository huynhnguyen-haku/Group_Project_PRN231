document.addEventListener('DOMContentLoaded', (event) => {
    const ctx = document.getElementById('accountChart');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            datasets: [{
                label: 'Total Sign-up Account',
                data: [12, 19, 3, 5, 2, 3, 26, 9, 30, 45, 11, 22],
                backgroundColor: '#FCE7F3',
                borderWidth: 1,
                borderColor: '#FBCFE8',
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                    grid: {
                        display: false
                    }
                }
            },
            responsive: true,
        }
    });
});