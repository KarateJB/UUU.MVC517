var app = new Vue({
    el: '#app',
    data: {
        sysinfo: {}
    },
    methods: {
        getSysInfo: function () {
            var vm = this;
            axios.get('Home/SysInfo').then(function (response) {

                console.log(response.data);
                vm.sysinfo = response.data;


            }, function (error) {
                console.log(error.statusText);
            });
        }
    },
    mounted: function () {
        this.getSysInfo();
    }
})