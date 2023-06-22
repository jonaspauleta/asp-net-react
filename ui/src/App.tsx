import { ApplicationContainer } from "./components/ApplicationContainer";
import { TextInput, Button, Box, Group } from '@mantine/core';
import { useForm } from '@mantine/form';
import { Card } from "./components/Card";
import { useState } from 'react';

interface request{
  city: string;
}

interface IStatusData{
  city: string;
  region: string;
  country: string;
  localTime: string;
  temperature: string;
  sunrise: string;
  sunset: string;
}

function App() {
  const form = useForm({
    initialValues: {
      city: '',
    },
  });

  const [statusData, setStatusData] = useState<IStatusData[]>([]);
  const [errorMessage, setErrorMessage] = useState('');

  function handleSubmit(values: request) {
    console.log(errorMessage);
    fetch(process.env.REACT_APP_API_URL + '/Status/' + values.city)
        .then(response => response.json())
        .then(data => {
          if ('error' in data) {
            setErrorMessage(data.error.message);
          } else {
            setStatusData((result) => ([...result, data]));

            console.log(data);
          }
        });
  }

  return (
    <ApplicationContainer>
      <Box sx={{ maxWidth: 500 }} mx="auto">
        <form onSubmit={form.onSubmit((values) => handleSubmit(values))}>
          {(errorMessage === '') 
            ? 
            <TextInput placeholder="City" label="See weather status for the prefered city" required {...form.getInputProps('city')} /> 
            :
            <TextInput placeholder="City" label="See weather status for the prefered city" required error={errorMessage} {...form.getInputProps('city')}/>
          }
          
          <Group position="right" mt="md">
            <Button type="submit" radius="xl" size="lg" style={{
              backgroundColor: '#002F6C'
            }}>
              Get the data
            </Button>
          </Group>
        </form>

        {statusData.reverse().map((element, index) => {
          return (
            <Card key={index} location={element.city + ", " + element.region + ", " + element.country} date={element.localTime} temp={element.temperature} sunrise={element.sunrise} sunset={element.sunset} />
          )
        })}
      </Box>
    </ApplicationContainer>
  );
}

export default App;
