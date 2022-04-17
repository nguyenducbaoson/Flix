function nguoidung() {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/NguoiDung',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Danh sách người dùng</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" " onclick="formthemnguoidung()">Thêm</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><thead><tr><th>Email</th><th>Tên Người Dùng</th><th>Mật Khẩu</th><th style="text-align: center">Chức năng</th></tr></thead><tbody>';
            $.each(data, function (key, val) {
                str += '<tr><td style="text-align: center">' + val.Email + '</td><td style="text-align: center"><p>' + val.FullName + '</p></td><td style="text-align: center"><p>' + val.Password + '</p></td><td style="width: 14%; text-align: center"><a type="submit" onclick="formsuanguoidung(\'' + val.Email + '\')" class="btn btn-primary btn-icon-split"><span class="icon text-white-50"><i class="fas fa-edit"></i></span></a><a type="submit" onclick="xoanguoidung(\'' + val.Email + '\')" class="btn btn-danger btn-icon-split"><span class="icon text-white-50"><i class="fas fa-trash"></i></span></a></td></tr> ';
            });
            str += '</tbody></table></div></div></div>';
            $('#Display').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formsuanguoidung(email) {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/NguoiDung?email=' + email,
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Sửa người dùng</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="nguoidung()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><tbody>';
            str += '<tr><td>Email</td><td><label>' + data.Email + '</label></td></tr><tr><td>Tên Người Dùng</td><td><input id="ten" type="text" value="' + data.FullName + '"></td></tr><tr><td>PassWord</td><td><input id="pass" type="text" value="' + data.Password + '"></td></tr><tr><td><button type="submit" class="btn btn-success" id="but">Lưu Cập Nhật</button></td><td></td></tr>';
            str += '</tbody></table></div></div></div>';
            $('#Display').html(str);
            $('#but').click(function () {
                $.ajax({
                    type: 'PUT',
                    url: 'https://localhost:44301/api/NguoiDung/update?email=' + data.Email + '&fullname=' + $('#ten').val().toString() + '&pass=' + $('#pass').val().toString(),
                    dataType: 'json',
                    success: function (data) {
                        if (data == false)
                            alert("Sửa Không Thành Công");
                        else {
                            alert("Sửa Thành Công");
                            $('#Display').ready(function () {
                                nguoidung();
                            });
                        }
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });
            });
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formthemnguoidung() {
    $('#Display').empty();
    var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Thêm Người dùng</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="nguoidung()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><tbody>';
    str += '<tr><td>Email</td><td><input id="email" type="text"></td></tr><tr><td>Tên Người Dùng</td><td><input id="ten" type="text"></td></tr><tr><td>Password</td><td><input id="pass" type="text"></td></tr><tr><td><button type="submit" class="btn btn-success" id="but">Thêm</button></td><td></td></tr>';
    str += '</tbody></table></div></div></div>';
    $('#Display').html(str);
    $('#but').click(function () {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44301/api/NguoiDung/insert?email=',
            data: {
                email: $('#email').val().toString(),
                fullname: $('#ten').val().toString(),
                password: $('#pass').val().toString(),
            },
            dataType: 'json',
            success: function (data) {
                if (data == false)
                    alert("Thêm Không Thành Công");
                else {
                    alert("Thêm Thành Công");
                    $('#Display').ready(function () {
                        nguoidung();
                    });
                }
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });



}
function xoanguoidung(email) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44301/api/NguoiDung/delete?email=' + email,
        dataType: 'json',
        success: function (data) {
            if (data == false)
                alert("Xóa Không Thành Công");
            else {
                alert("Xóa Thành Công");
                $('#Display').ready(function () {
                    nguoidung();
                });
            }
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}