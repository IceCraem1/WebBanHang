document.addEventListener("DOMContentLoaded", function () {
    var switchLink = document.getElementById('switchLink');
    var registerFields = document.getElementById('registerFields');
    var authButton = document.getElementById('authButton');
    var authForm = document.getElementById('authForm');

    switchLink.addEventListener('click', function (event) {
        event.preventDefault();
        registerFields.style.display = 'block';
        authButton.textContent = 'Đăng ký';
        authButton.setAttribute('formaction', '/Account/Register');
        switchLink.textContent = 'Đã có tài khoản? Đăng nhập';
        authForm.setAttribute('method', 'post');
    });
});
document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById('authForm');
    var usernameInput = document.getElementById('sTenDangNhap');
    var passwordInput = document.getElementById('sMatKhau');
    var errorDisplay = document.getElementById('errorDisplay');

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Ngăn chặn việc gửi form đi mặc định

        var username = usernameInput.value;
        var password = passwordInput.value;

        // Kiểm tra xem tên đăng nhập và mật khẩu có được nhập hay không
        if (username.trim() === '' || password.trim() === '') {
            displayError('Vui lòng nhập tên đăng nhập và mật khẩu.');
            return;
        }

        // Gửi thông tin đăng nhập đến máy chủ (chưa được thực hiện trong ví dụ này)
        // Nếu thông tin đúng, chuyển hướng người dùng đến trang chính
        // Nếu thông tin sai, hiển thị thông báo lỗi
        if (username === 'admin' && password === 'password') {
            // Đăng nhập thành công
            window.location.href = '/home'; // Chuyển hướng đến trang chính
        } else {
            // Đăng nhập không thành công
            displayError('Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.');
        }
    });

    function displayError(message) {
        errorDisplay.textContent = message;
    }
});
