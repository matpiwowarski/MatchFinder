function getStadiumJson(countryName)
{
    $.get('index.php?r=stadium/stadium-array-json&countryName=' + countryName + '&json=true)', function(data)
    {
        stadiumArray = JSON.parse(data);
        window.alert(stadiumArray[0].latitude);
    }
    )
}
