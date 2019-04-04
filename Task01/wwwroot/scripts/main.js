
// Получение всех пользователей
function GetDepartments() {
   $.ajax({
        url: '/api/department',
        type: 'Get',
        contentType: "application/json",
        success: function (selectValues) {
            var $mySelect = $('#dep');
            $.each(selectValues, function (key, value) {
                var $option = $("<option/>", {
                    value: key,
                    text: value.title
                });
                $mySelect.append($option);
            })
            
        }
    });
}
           
  



// Получение всех пользователей
    function GetUsers() {
        $.ajax({
            url: '/api/users',
            type: 'GET',
            contentType: "application/json",
            success: function (users) {
                var rows = "";
                $.each(users, function (index, user) {
                    // добавляем полученные элементы в таблицу
                    rows += row(user);
                })
                $("table tbody").append(rows);
            }
        });
    }
        // Получение одного пользователя
        function GetUser(id) {
        $.ajax({
            url: '/api/users/' + id,
            type: 'GET',
            contentType: "application/json",
            success: function (user) {
                var form = document.forms["userForm"];
                form.elements["id"].value = user.id;
                form.elements["userName"].value = user.username;
                form.elements["title"].value = user.title;
            }
        });
    }
        // Добавление пользователя
        function CreateUser(username, departmentId, userId) {
        $.ajax({
            url: "api/users",
            contentType: "application/json",
            method: "POST",
            data: JSON.stringify({
                userName: username,
                title: departmentId,
                id: userId
            }),
            success: function (user) {
                reset();
                $("table tbody").append(row(user));
            }
        })
    }
    // Изменение пользователя
        function EditUser(userId, username, departmentid) {
        $.ajax({
            url: "api/users",
            contentType: "application/json",
            method: "PUT",
            data: JSON.stringify({
                id: userId,
                userName: username,
                title: departmentid
            }),
            success: function (user) {
                reset();
                $("tr[data-rowid='" + user.id + "']").replaceWith(row(user));
            }
        })
    }

    // сброс формы
    function reset() {
            var form = document.forms["userForm"];
            form.reset();
            form.elements["id"].value = 0;
        }

        // Удаление пользователя
        function DeleteUser(id) {
        $.ajax({
            url: "api/users/" + id,
            contentType: "application/json",
            method: "DELETE",
            success: function (user) {
                $("tr[data-rowid='" + user.id + "']").remove();
            }
        })
    }
    // создание строки для таблицы
    var row = function (user) {
            return "<tr data-rowid='" + user.id + "'><td class=\"nr\">" + user.id + "</td>" +
                "<td>" + user.userName + "</td> <td>" + user.title + "</td>";
        }
        // загрузка пользователей
        GetUsers();
        GetDepartments();
        var ChangedId = 0;

        $(function () {
        $('.table-select').on('click', 'tr', function () {
            var self = $(this);
            self.closest('table').find('tr').removeClass('active');
            self.closest('tr').addClass('active');
            var $row = $(this).closest("tr");    // Find the row
            ChangedId = $row.find(".nr").text(); // Find the text
        });
    })

        function myFunction() {
            GetUser(ChangedId);
        }
        function myFunction1() {
            DeleteUser(ChangedId);
            ChangedId = 0;
    }
        function myFunction0() {
           
            console.log(12);
            if (ChangedId == 0) {
                var id = 0;
            }
                var username = document.getElementById("username").value;
                var departmentid = document.getElementById("title").value;
                console.log(username);
                console.log(departmentid);
                if (id == 0) {
                    var rows = window.document.querySelectorAll("table tbody tr");
                    var mySet = new Set();
                    for (var i = 0; i < rows.length; i++) { // перебираем все строки
                        var cols = rows[i].querySelectorAll('td'); // получаем столбцы
                        mySet.add(cols[0].textContent); // выводим текст из столбца
                    }
                    id = 1;
                    var arr = Array.from(mySet).sort();
                    for (var i = 0; i < arr.length; i++) {
                        if (arr[i] == id) {
                            id++;
                        }
                        else {
                            break;
                        }
                    }
                    console.log(1);
                    CreateUser(username, departmentid, id);
                }
                else
                    EditUser(ChangedId, username, departmentid);
                ChangedId = 0;
         }