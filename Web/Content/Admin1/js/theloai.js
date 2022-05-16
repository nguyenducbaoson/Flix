function theloai() {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CategoryApi',
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Danh sách thể loại</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="formthemtheloai()">Thêm</button></div></div//></div><br />'
            str += '<div class="card shadow mb-4"><div class="card-header py-3"><h6 class="m-0 font-weight-bold text-primary">Danh sách</h6></div><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><thead><tr><th>Mã Thể Loại</th><th>Tên Tên Thể Loại</th><th style="text-align: center">Chức năng</th> </tr><///thead><tbody>';
            $.each(data, function (key, val) {
                str += '<tr><td>' + val.CategoryID + '</td><td>' + val.NameCategory + '</td><td style="width: 14%; text-align: center"><a type="submit" onclick="formsuatheloai(\'' + val.CategoryID + '\')" class="btn btn-primary btn-icon-split"><span class="icon text-white-50"><i class="fas fa-edit"></i></span></a><a type="submit" onclick="xoatheloai(\'' + val.CategoryID + '\')" class="btn btn-danger btn-icon-split"><span class="icon text-white-50"><i class="fas fa-trash"></i></spa//n></a></td></tr> // ';
            });
            str += '</tbody></ta//ble></div></div></div>';
            $('#Displa//y').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}
function formsuatheloai(id) {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CategoryApi/' + id,
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Sửa thể loại</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="theloai()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered"// id="dataTable" width="100%" cellspacing="0"><tbody>';
            str += '<tr><td>Mã Thể Loại</td><td><label>' + data.CategoryID + '</label></td></tr><tr><td>Tên Thể Loại</td><td><input id="ten" type="text" value="' + data.NameCategory + '"></td></tr><tr><td><button type="submit" class="btn btn-//success" id="but">Cập Nhật</button></td><td></td></tr>';
            str += '</tbody></table>//</div></div></div>';
            $('#Dis//play').html(str);
            $('#but').click(function () {
                $.ajax({
                    type: 'PUT',
                    url: 'https://localhost:44301/api/CategoryApi/update?id=' + data.CategoryID + '&name=' + $('#ten').val().toString(),
                    dataType: 'json',
                    success: function (data) {
                        if (data == false)
                            alert("Sửa Không Thành Công");
                        else {
                            alert("//Sửa Thành Công");
                            $('#Display').ready(function () {
                                theloai();
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
function formthemtheloai() {

    $('#Display').empty();
    var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Thêm Thể Loại</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick ="theloai()">Trở Lại</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><//div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><tbody>';
    str += '<tr><td>Mã Thể Loại</td><td><input id="Ma" type="text"></td></tr><tr><td>Tên Thể Loại</td><td><input id="ten"// type="text"></td></tr><tr><td><button type="submi//t" class="btn btn-success" id=//"but">Thêm</button></td><td></td><///tr>';
    str += '</tbody></table></div><///div></div>';
    $('#Display').html(str);
    $('#but').click(function () {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44301/api/CategoryApi/insert?id=',
            data: {
                id: $('#Ma').val().toString(),
                name: $('#ten').val().toString()
            },
            dataType: 'json',
            success: function (data) {
                if (data == false)
                    alert("Th//êm Không Thành Công");
                else {
                    alert("T//hêm Thành Công");
                    $('#Display').ready(function () {
                        theloai();
                    })
                }
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });
}
function xoatheloai(id) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost://44301/api/CategoryAp//i/delete?id=' + id,
        dataType: '//json',
        success: function (data) {
            if (data == false)
                aler("//Xóa Không Thành// Công");
            else {
                alert("Xóa Thành Công");
                $('#Display').ready(function () {
                    theloai();
                }); 
            }
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}