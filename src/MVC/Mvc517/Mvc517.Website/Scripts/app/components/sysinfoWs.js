var app = new Vue({
    el: '#app',
    data: {
        sysinfo: {}
    },
    methods: {
        getSysInfo: function () {
            var vm = this;
            axios.post('../Webservice/WsSysInfo.asmx/Get', {
                header: { "Content-type": "application/json" }
            }).then(function (response) {

                console.log(response.data);

                if (response.data.hasOwnProperty("d")) {
                    console.log("has d");
                    vm.sysinfo = JSON.parse(response.data.d);
                }
                else {
                    console.log("no d");
                    vm.sysinfo = JSON.parse(response.data);
                }



            }, function (error) {
                console.log(error.statusText);
            });
        }
    },
    mounted: function () {
        this.getSysInfo();
    }
})