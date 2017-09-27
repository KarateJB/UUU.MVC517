var app = new Vue({
    el: '#app',
    data: {
        sysinfo: {},
        currentUsers: []
    },
    methods: {
        getSysInfo: function () {
            return axios.get('/Ajax/SysInfo');
            //var vm = this;
            //axios.get('Ajax/SysInfo').then(function (response) {

            //    vm.sysinfo = response.data;

            //}, function (error) {
            //    console.log(error.statusText);
            //});
        },

        getCurrentUsers: function () {
            return axios.get('/Ajax/CurrentUsers');
            //var vm = this;
            //axios.get('Ajax/CurrentUsers').then(function (response) {

            //    vm.currentUsers = response.data;

            //}, function (error) {
            //    console.log(error.statusText);
            //});
        }
    },
    mounted: function () {
        var vm = this;

        //vm.getSysInfo();
        //vm.getCurrentUsers();

        axios.all([this.getSysInfo(), this.getCurrentUsers()])
            .then(axios.spread(function (sys, users) {
                vm.sysinfo = sys.data;
                vm.currentUsers = users.data;
            }));

    }
})