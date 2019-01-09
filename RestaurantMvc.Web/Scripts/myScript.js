$(function () {
    $('#datePicker').datetimepicker({
        format: 'L'
    });

    $('.timePicker')
        .datetimepicker({
            format: 'HH:mm',
            stepping: 30,
            enabledHours: [12, 13, 14, 15, 16, 17, 18, 19, 20 ,21 ,22 ,23]

        });
});

function goBack() {
    window.history.back();
}



