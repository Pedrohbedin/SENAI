import { StatusBar } from 'react-native';
import { ContainerApp } from './style';
import { Header } from './src/components/Header';
import { useFonts, Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';

export default function App() {
  let [fontsLoaded] = useFonts({
    Roboto_500Medium, Roboto_700Bold
  });
  return (
    <ContainerApp>
      <StatusBar backgroundColor='#FECC2B' />
      <Header />
    </ContainerApp>
  );
}
