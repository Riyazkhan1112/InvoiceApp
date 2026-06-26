document.addEventListener("DOMContentLoaded", function () {

    fetch("/api/invoice")

        .then(response => response.json())

        .then(data => {

            let html = "";

            html += `<h2>Invoice No : ${data.invoiceNo}</h2>`;
            html += `<h3>Customer : ${data.customer}</h3>`;
            html += `<h4>Date : ${data.date}</h4>`;

            html += "<table>";

            html += `
            <tr>
                <th>Item</th>
                <th>Price</th>
            </tr>
            `;

            data.items.forEach(item => {

                html += `
                <tr>
                    <td>${item.name}</td>
                    <td>${item.price}</td>
                </tr>
                `;

            });

            html += `
            <tr>

                <td><b>Total</b></td>

                <td><b>${data.total}</b></td>

            </tr>
            `;

            html += "</table>";

            document.getElementById("invoice-container").innerHTML = html;

        })

        .catch(error => {

            console.error(error);

            document.getElementById("invoice-container").innerHTML =
                "<h2>Unable to load invoice.</h2>";

        });

});