document.addEventListener('DOMContentLoaded', (event) => {
    const ctx = document.getElementById('revenue');

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
            datasets: [
                {
                    data: [186, 205, 1321, 1516, 2107, 2191, 3133, 3221, 4783, 5478],
                    label: 'Sales',
                    borderColor: "#EC4899",
                    fill: false
                }]
        },
        options: {
            scales: {
                x: {
                    beginAtZero: true,
                    grid: {
                        display: false
                    }
                },
                y: {
                    beginAtZero: true,
                    grid: {
                        display: false
                    }
                }

            }
        }
    });
});