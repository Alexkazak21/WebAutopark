// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




function addVehicleButtons(row, VehicleId, VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color, FuelConsumption ) {
    // Remove buttons from other rows if already added
    document.querySelectorAll("tbody tr").forEach(tr => {
        if (tr !== row) {
            tr.lastElementChild.innerHTML = ""; // Clear buttons from other rows
        }
    });

    // Check if buttons are already there
    if (row.lastElementChild.innerHTML.trim() !== "") {
        row.lastElementChild.innerHTML = ""; // Remove buttons on second click
        return;
    }

    // Create buttons
    let editBtn = document.createElement("button");
    editBtn.innerText = "Edit";
    editBtn.className = "btn btn-warning btn-sm me-2";
    editBtn.onclick = function () { openVehicleEditModal(VehicleId, VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color, FuelConsumption); };

    let deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Delete";
    deleteBtn.className = "btn btn-danger btn-sm me-2";
    deleteBtn.onclick = function () { confirmVehicleDelete(VehicleId); };

    // Append buttons to the last cell in the row
    row.lastElementChild.appendChild(editBtn);
    row.lastElementChild.appendChild(deleteBtn);
}

function addTypeButtons(row, id, name, taxCoefficient) {
    // Remove buttons from other rows if already added
    document.querySelectorAll("tbody tr").forEach(tr => {
        if (tr !== row) {
            tr.lastElementChild.innerHTML = ""; // Clear buttons from other rows
        }
    });

    // Check if buttons are already there
    if (row.lastElementChild.innerHTML.trim() !== "") {
        row.lastElementChild.innerHTML = ""; // Remove buttons on second click
        return;
    }

    // Create buttons
    let editBtn = document.createElement("button");
    editBtn.innerText = "Edit";
    editBtn.className = "btn btn-warning btn-sm me-2";    
    editBtn.onclick = function () { openTypeEditModal(id, name, taxCoefficient); };

    let deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Delete";
    deleteBtn.className = "btn btn-danger btn-sm me-2";
    deleteBtn.onclick = function () { confirmTypeDelete(id); };

    // Append buttons to the last cell in the row
    row.lastElementChild.appendChild(editBtn);
    row.lastElementChild.appendChild(deleteBtn);
}

function addOrderButtons(row, OrderId, VehicleId, Date) {
    // Remove buttons from other rows if already added
    document.querySelectorAll("tbody tr").forEach(tr => {
        if (tr !== row) {
            tr.lastElementChild.innerHTML = ""; // Clear buttons from other rows
        }
    });

    // Check if buttons are already there
    if (row.lastElementChild.innerHTML.trim() !== "") {
        row.lastElementChild.innerHTML = ""; // Remove buttons on second click
        return;
    }

    // Create buttons
    let editBtn = document.createElement("button");
    editBtn.innerText = "Edit";
    editBtn.className = "btn btn-warning btn-sm me-2";
    editBtn.onclick = function () { openOrderEditModal(OrderId, VehicleId, Date); };

    let deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Delete";
    deleteBtn.className = "btn btn-danger btn-sm me-2";
    deleteBtn.onclick = function () { confirmOrderDelete(OrderId); };

    // Append buttons to the last cell in the row
    row.lastElementChild.appendChild(editBtn);
    row.lastElementChild.appendChild(deleteBtn);
}

function openVehicleEditModal(VehicleId, VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color, FuelConsumption) {
    // Set values in modal input fields
    document.getElementById("editVehicleId").value = VehicleId;
    document.getElementById("editVehicleTypeId").value = VehicleTypeId;
    document.getElementById("editModel").value = Model;
    document.getElementById("editRegistrationNumber").value = RegistrationNumber;
    document.getElementById("editWeight").value = Weight;
    document.getElementById("editYear").value = Year;
    document.getElementById("editMileage").value = Mileage;
    document.getElementById("editColor").value = Color;
    document.getElementById("editFuelConsumption").value = FuelConsumption;

    // Open Bootstrap modal
    new bootstrap.Modal(document.getElementById("editVehicleModal")).show();
}

function openTypeEditModal(id, name, taxCoefficient) {
    // Set values in modal input fields
    document.getElementById("editVehicleTypeId").value = id;
    document.getElementById("editVehicleTypeName").value = name;
    document.getElementById("editTaxCoefficient").value = taxCoefficient;

    // Open Bootstrap modal
    new bootstrap.Modal(document.getElementById("editTypeModal")).show();
}

function saveTypeEdit() {
    let id = document.getElementById("editVehicleTypeId").value;
    let updatedName = document.getElementById("editVehicleTypeName").value;
    let updatedTaxCoefficient = parseFloat(document.getElementById("editTaxCoefficient").value.replace(",", "."));

    fetch(`/VehicleType/Update`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            VehicleTypeId: id,
            Name: updatedName,
            TaxCoefficient: parseFloat(updatedTaxCoefficient)
        })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                // Update table row dynamically
                document.querySelector(`tr[data-id='${id}'] td:nth-child(2)`).innerText = updatedName;
                document.querySelector(`tr[data-id='${id}'] td:nth-child(3)`).innerText = updatedTaxCoefficient;

                // Close modal
                let modal = bootstrap.Modal.getInstance(document.getElementById("editModal"));
                modal.hide();
            } else {
                alert(data.message);
            }
        })
        .catch(error => console.error("Error:", error));
}

function saveVehicleEdit() {
    let vehicleId = document.getElementById("editVehicleId").value;
    let vehicleTypeId = document.getElementById("editVehicleTypeId").value;
    let vehicleModel = document.getElementById("editModel").value;
    let vehicleRegNumber = document.getElementById("editRegistrationNumber").value;
    let vehicleWeight = document.getElementById("editWeight").value;
    let vehicleYear = document.getElementById("editYear").value;
    let vehicleMileage = document.getElementById("editMileage").value;
    let vehicleColor = document.getElementById("editColor").value;
    let vehicleFuelConsumption = parseFloat(document.getElementById("editFuelConsumption").value.replace(",", "."));

    fetch(`/Vehicle/Update`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            VehicleId: vehicleId,
            VehicleTypeId: vehicleTypeId,
            Model: vehicleModel,
            RegistrationNumber: vehicleRegNumber,
            Weight: vehicleWeight,
            Year: vehicleYear,
            Mileage: vehicleMileage,
            Color: vehicleColor,
            FuelConsumption: parseFloat(vehicleFuelConsumption)
        })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            // Update table row dynamically
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(2)`).innerText = vehicleTypeId;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(3)`).innerText = vehicleModel;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(4)`).innerText = vehicleRegNumber;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(5)`).innerText = vehicleWeight;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(6)`).innerText = vehicleYear;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(7)`).innerText = vehicleMileage;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(8)`).innerText = vehicleColor;
            document.querySelector(`tr[data-id='${vehicleId}'] td:nth-child(9)`).innerText = vehicleFuelConsumption;

            // Close modal
            let modal = bootstrap.Modal.getInstance(document.getElementById("editVehicleModal"));
            modal.hide();
        } else {
            alert(data.message);
        }
    })
    .catch(error => console.error("Error:", error));
}

function confirmTypeDelete(id) {
    if (confirm("Are you sure you want to delete this item VehicleTypeId = " + id + "?")) {

        fetch(`/VehicleType/Delete/${id}`, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert("Vehicle Type deleted successfully!");
                    document.querySelector(`tr[data-id='${id}']`).remove(); // Remove row from table
                } else {
                    alert(data.message);
                }
            })
            .catch(error => console.error("Error:", error));
    }
}

function confirmVehicleDelete(id) {
    if (confirm("Are you sure you want to delete this item VehicleId = " + id + "?")) {

        fetch(`/Vehicle/Delete/${id}`, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert("Vehicle deleted successfully!");
                    document.querySelector(`tr[data-id='${id}']`).remove(); // Remove row from table
                } else {
                    alert(data.message);
                }
            })
            .catch(error => console.error("Error:", error));
    }
}