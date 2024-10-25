d3.csv('cleaned_data_set.csv',

    // How to format each row. Since the CSV file has a header, `row` will be
    // an object with keys derived from the header.
    function(row) {
      return {name : row.name, age : +row.age, color : row.color};
    },

    // Callback to run once all data's loaded and ready.
    function(data) {
      // Log the data to the JavaScript console
      console.log(data);

      // Compute some interesting results
      var averageAge = data.reduce(function(prev, curr) {
        return prev + curr.age;
      }, 0) / data.length;

      // Also, display it
      var ulSelection = d3.select('body').append('ul');
      var valuesSelection =
          ulSelection.selectAll('li').data(data).enter().append('li').text(
              function(d) { return d.age; });
      var totalSelection =
          ulSelection.append('li').text('Average: ' + averageAge);
    });