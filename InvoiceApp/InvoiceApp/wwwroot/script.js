document.addEventListener("DOMContentLoaded", () => {

    fetch("https://invoiceapp-dimw.onrender.com/api/invoice")
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to load invoice");
            }
            return response.json();
        })
        .then(data => {

            let html = `
                <h2>Invoice No : ${data.invoiceNo}</h2>
                <h3>Customer : ${data.customer}</h3>
                <h4>Date : ${data.date}</h4>

                <table>
                    <thead>
                        <tr>
                            <th>Item</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
            `;

            data.items.forEach(item => {
                html += `
                    <tr>
                        <td>${item.name}</td>
                        <td>$${item.price.toFixed(2)}</td>
                    </tr>
                `;
            });

            html += `
                    <tr>
                        <td><strong>Total</strong></td>
                        <td><strong>$${data.total.toFixed(2)}</strong></td>
                    </tr>
                    </tbody>
                </table>
            `;

            document.getElementById("invoice-container").innerHTML = html;
        })
        .catch(error => {
            console.error(error);
            document.getElementById("invoice-container").innerHTML =
                "<h2>Unable to load invoice.</h2>";
        });

});