import React from 'react';
import styles from './CohortDetails.module.css'; // Step 2

function CohortDetails(props) {
  return (
    <div className={styles.box}> {/* Step 3 */}
      <h3 style={{ color: props.cohort.currentStatus === "ongoing" ? "green" : "blue" }}> {/* Step 4 */}
        {props.cohort.cohortCode} - <span>{props.cohort.technology}</span>
      </h3>
      <dl>
        <dt>Started On</dt>
        <dd>{props.cohort.startDate}</dd>
        <dt>Current Status</dt>
        <dd>{props.cohort.currentStatus}</dd>
        <dt>Coach</dt>
        <dd>{props.cohort.coachName}</dd>
        <dt>Trainer</dt>
        <dd>{props.cohort.trainerName}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;
