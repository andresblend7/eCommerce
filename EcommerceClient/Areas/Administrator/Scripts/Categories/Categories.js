let categoriesAppVue = new Vue({
    el: '#categories-app',
    data: {
        categories: [{}],
        category: {
            id: null,
            name: null,
            description: null,
            status: true
        },
        //Flag para modal de ditar o crear
        flagEdit: false,
        loading: false,
        categoryTarget: 0,
        succsessMsg: "default",
        //propiedad de validación de formulario
        validationWrong: true
    },
    watch: {

        deep: true,
        'category.name': {
            handler(val) {
                if (val.trim().length < 2 || val.trim().length > 15) {
                        this.validationWrong = true;
                } else {
                   this.validationWrong = false;
                }
            }
        }

    },
    methods: {

        restartCategory: function () {

            this.category.id = null;
            this.category.name = null;
            this.category.description = null;
            this.category.status = true;

            this.flagEdit = false;
        },

        setTarget: function ($target) {
            this.categoryTarget = $target.id;

            Object.assign(this.category, $target);

            this.flagEdit = true;
        },

        deleteCategory: function () {

            this.loading = true;

            console.log(this.categoryTarget);

            if (this.categoryTarget != 0) {
                //Realizamos la petición
                $Core.Ajax("Categories", "Delete", { id: this.categoryTarget }, function ($response) {

                    //Validamos la eliminación de la categoria
                    if ($response.control) {
                        $("#modalConfirmacion").modal("hide");

                        categoriesAppVue.succsessMsg = "Categoria eliminada satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);


                    } else {
                        
                    }

                    this.loading = false;

                }, function ($response) {

                    alert("ERROR ", $response);

                });
            }

        },

        //Método encargado de la creación y actualización de la categoria
        processCategory: function () {

            this.loading = true;

            //Realizamos el UpperCase CamellCase
            $Core.PrepareObject(this.category);

            if (!this.flagEdit) {
                //Creación de una categoria

                //Realizamos la petición
                $Core.Ajax("Categories", "Create", this.category, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        categoriesAppVue.succsessMsg = "Categoria creada satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    categoriesAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));
            }
            else {
                //Edición de una categoria

                //Realizamos la petición
                $Core.Ajax("Categories", "Update", this.category, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        categoriesAppVue.succsessMsg = "Categoria actualizada satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    categoriesAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));

            }


        },

        changeStatus: function ($category, $index) {

            console.log($category);

            //Realizamos la petición
            $Core.Ajax("Categories", "ChangeStatus", { id: $category.id }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Estado actualizado');

                    //Actualizamos el objeto
                    categoriesAppVue.categories[$index].status = !$category.status;

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {

                alert("ERROR ", $response);

            });

        },

        initData: function ($model) {

            console.log($model.categories);

            this.categories = $model.categories;

        }

    }

});