import {
    AppShell,
    Footer,
    Group,
    Header,
    Text
} from '@mantine/core'
import { InsurwaveLogo } from './InsurwaveLogo';

export const ApplicationContainer = ({children}: any) => {
    return (
        <AppShell
            styles = {{
                main: {
                    background: '#FFFFFF',
                    width: '100vw',
                    height: '100vw',
                    paddingLeft: '0px'
                }
            }}
            fixed
            header = {
                <Header height={70} p="md">
                    <div style = {{
                        display: 'flex',
                        alignItems: 'center',
                        height: '100%'
                    }}>
                        <InsurwaveLogo />
                    </div>
                </Header>
            }
            footer = {
                <Footer height={60} p="md">
                    <Group position="apart" spacing="xl">
                        <Text size="sm">
                            <span style = {{
                                fontWeight: 'bolder'
                            }}>
                                👨🏻‍💼 Made for Ardanis
                            </span>
                        </Text>

                        <Text size="sm">
                            <span style = {{
                                fontWeight: 'bolder'
                            }}>
                                By João Paulo Santos 🤓
                            </span>
                        </Text>
                    </Group>
                </Footer>
            }
        >
            {children}
        </AppShell>
    );   
}