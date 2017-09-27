var app = new Vue({
    el: '#app',
    data: {
        operas: {},
        createUri: "/Rest/Create/",
        editUri: "/Rest/Edit/",
        deleteUri: "/Rest/Delete/",

    },
    methods: {
        getOperas: function () {
            return axios.get('/api/RestApi/Get');
        }
    },
    mounted: function () {
        var vm = this;

        vm.getOperas().then(response => {
            vm.operas = response.data;
        });
    }
})