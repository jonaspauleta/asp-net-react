import React from "react";
import { createStyles, Paper, Text } from "@mantine/core";
import { Cloud } from "tabler-icons-react";

const useStyles = createStyles((theme) => ({
  card: {
    position: "relative",
    cursor: "pointer",
    overflow: "hidden",
    transition: "transform 150ms ease, box-shadow 100ms ease",
    padding: theme.spacing.xl,
    paddingLeft: theme.spacing.xl * 2,

    "&:hover": {
      boxShadow: theme.shadows.md,
      transform: "scale(1.02)",
    },

    "&::before": {
      content: '""',
      position: "absolute",
      top: 0,
      bottom: 0,
      left: 0,
      width: 6,
      backgroundImage: theme.fn.linearGradient(0, "#E87722", "#002F6C"),
    },
  },
}));

interface CardProps {
  location: string;
  date: string;
  temp: string;
  sunrise: string;
  sunset: string;
}

export function Card({ location, date, temp, sunrise, sunset }: CardProps) {
  const { classes } = useStyles();

  return (
    <Paper withBorder mt="lg" radius="md" className={classes.card}>
      <Cloud size={32} />

      <Text size="xl" weight={500} mt="md">
        {location}
      </Text>

      <Text size="lg" mt="xs" color="dimmed">
        {date}
      </Text>

      <Text size="lg" mt="xs" color="dimmed">
        {temp}°C
      </Text>

      <Text size="md" mt="xs" color="dimmed">
        Sunrise: {sunrise}
      </Text>

      <Text size="md" mt="xs" color="dimmed">
        Sunset: {sunset}
      </Text>
    </Paper>
  );
}
