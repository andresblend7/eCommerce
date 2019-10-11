let UsersAppVue = new Vue({
    el: '#users-app',
    data: {
        users: [{}],
        user: {
            id: 0,
            rol: 2,
            money: 0,
            firstName: '',
            lastName: '',
            email: '',
            address: 'ad',
            phone: '',
            hashPassword: '',
            status: true
        },
        //Flag para modal de ditar o crear
        flagEdit: false,
        loading: false,
        userTarget: 0,
        succsessMsg: "default"
    },
    methods: {

        restartUser: function () {
            this.flagEdit = false;
            this.user = {
                id: 0,
                rol: 2,
                money: 0,
                firstName: '',
                lastName: '',
                email: '',
                address: 'ad',
                phone: '',
                hashPassword: '',
                status: true
            }
        },

        setTarget: function ($target) {

            this.userTarget = $target.id;

            Object.assign(this.user, $target);

            this.flagEdit = true;
        },
      
        //Método encargado de la creación y actualización del usuario
        processUser: function () {

            this.loading = true;

            //Realizamos el UpperCase CamellCase
            $Core.PrepareObject(this.user);

            if (!this.flagEdit) {
                //Creación de una categoria

                //Realizamos la petición
                $Core.Ajax("Users", "Create", this.user, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        UsersAppVue.succsessMsg = "Usuario Creado Satisfactoriamente.";

                        $("#succesUser").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    UsersAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));
            }
            else {
                //Edición de una categoria

                //Realizamos la petición
                $Core.Ajax("Users", "Update", this.user, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        UsersAppVue.succsessMsg = "Usuario actualizado satisfactoriamente.";

                        $("#succesUser").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    UsersAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));

            }


        },

        changeStatus: function ($user, $index) {

            console.log($user);

            //Realizamos la petición
            $Core.Ajax("Users", "ChangeStatus", { id: $user.id }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Estado actualizado');

                    //Actualizamos el objeto
                    UsersAppVue.users[$index].status = !$user.status;

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {

                alert("ERROR ", $response);

            });

        },




        initData: function ($model) {

            console.log($model);
            this.users = $model.users;

        }
    }
});