// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const addProductBtn = document.getElementById('addProductBtn');
const productContainer = document.getElementById('productContainer');

// Lắng nghe sự kiện click vào button "Thêm Sản Phẩm"
addProductBtn.addEventListener('click', () => {
    // Tạo một cột mới
    const newColumn = document.createElement('div');
    newColumn.classList.add('column');

    // Tạo thẻ img
    const img = document.createElement('img');
    img.src = 'placeholder.jpg'; // Thay đổi đường dẫn hình ảnh
    img.alt = 'Product';

    // Tạo nút "Add to Cart"
    const addToCartBtn = document.createElement('button');
    addToCartBtn.textContent = 'Add to Cart';
    addToCartBtn.classList.add('add-to-cart-btn');

    // Thêm ảnh và nút "Add to Cart" vào cột mới
    newColumn.appendChild(img);
    newColumn.appendChild(addToCartBtn);

    // Thêm cột mới vào container
    productContainer.appendChild(newColumn);
});
